import { ThrowStmt } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ProductComponent } from '../product.component';
@Component({
  selector: 'app-add-edit-prod',
  templateUrl: './add-edit-prod.component.html',
  styleUrls: ['./add-edit-prod.component.css']
})
export class AddEditProdComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() prod:any;
  SupplierList:any=[];
  CategoryList:any=[];
  SelectedItem:number=0;

  ProductId:number=0;
  SupplierId?:number;
  CategoryId?:number;
  ProductName:string="";
  QuantityPerUnit:string="";
  UnitPrice?:number;
  UnitsInStock?:number;
  UnitsOnOrder?:number;
  ReorderLevel?:number=0;
  Discontinued:boolean=false;
  ngOnInit(): void {
    this.service.getSuppList().subscribe(data=>{
      this.SupplierList=data;
      })
    
    this.service.getCategoryList().subscribe(data=>{
      this.CategoryList=data;
    })    
    this.ProductId=this.prod.ProductId;
    this.ProductName=this.prod.ProductName;
  }
  onSelectSupp(item){
    this.SupplierId=this.SupplierId
  }

  onSelectCategory(item){
    this.CategoryId=this.CategoryId
  }

  addProduct(){
    
    var val= {ProductId:this.ProductId,
              SupplierId:this.SupplierId,
              CategoryId:this.CategoryId,
              ProductName:this.ProductName,
              QuantityPerUnit:this.QuantityPerUnit,
              UnitPrice:this.UnitPrice,
              UnitsInStock:this.UnitsInStock,
              UnitsOnOrder:this.UnitsOnOrder,
              ReorderLevel:this.ReorderLevel,
              Discontinued:this.Discontinued}

    this.service.addProd(val).subscribe(res=>{
      alert("Product added successfully");
    })
  }

}
