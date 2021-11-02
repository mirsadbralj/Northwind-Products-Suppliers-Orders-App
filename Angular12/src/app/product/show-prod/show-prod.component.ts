import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-prod',
  templateUrl: './show-prod.component.html',
  styleUrls: ['./show-prod.component.css']
})
export class ShowProdComponent implements OnInit {

  constructor(private service:SharedService) { }

  ProductList:any=[];

  ModalTitle:string="";
  ActivateAddEditProdComp:boolean=false;
  prod:any;
  ngOnInit(): void {
    this.refreshProdList();
  }
  addClick(){
    this.prod={
      ProductId:0,
      ProductName:""
    }
    this.ModalTitle="Add Product";
    this.ActivateAddEditProdComp=true;
  }
  closeClick(){
    this.ActivateAddEditProdComp=false;
    this.refreshProdList();
  }

  deleteClick(item){
    if(confirm('Are you sure you want to delete record?'))
    this.service.deleteProduct(item.ProductId).subscribe(data=>{
      this.refreshProdList();
      alert("Deleted succesfully.")
    })
  }

  refreshProdList(){
    this.service.getProdList().subscribe(data=>{
      this.ProductList=data;
    })
  }

}
