import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { SupplierComponent } from '../supplier.component';

@Component({
  selector: 'app-show-supp',
  templateUrl: './show-supp.component.html',
  styleUrls: ['./show-supp.component.css']
})
export class ShowSuppComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  SupplierList:any=[];

  ngOnInit(): void {
    this.refreshSuppList();
  }

  refreshSuppList(){
    this.service.getSuppList().subscribe(data=>
      this.SupplierList=data);
  }
  deleteClick(item){
    if(confirm('Are you sure you want to delete record?'))
    this.service.deleteSupp(item.SupplierId).subscribe(data=>{
      this.refreshSuppList();
      alert("Deleted succesfully.")
    })
  }

}
