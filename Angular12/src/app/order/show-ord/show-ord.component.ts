import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-ord',
  templateUrl: './show-ord.component.html',
  styleUrls: ['./show-ord.component.css']
})
export class ShowOrdComponent implements OnInit {

  constructor(private service:SharedService) { }
  OrderList:any=[];
  ngOnInit(): void {
    this.refreshOrderList();
  }

  refreshOrderList(){
    this.service.getOrderList().subscribe(data=>{
      this.OrderList=data;
    })
  }

}
