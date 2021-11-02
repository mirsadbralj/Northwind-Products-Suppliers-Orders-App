import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:37243/api";
  
  constructor(private http:HttpClient) { }

  // -------------------------PRODUCT-------------------------
    getProdList():Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/product');
    }

    addProd(val:any){
      return this.http.post<any>(this.APIUrl+'/product',val);
    }

    deleteProduct(val:any){
      return this.http.delete<any>(this.APIUrl+'/product/'+val);
    }
    // ------------------------SUPPLIER-----------------------

    getSuppList():Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/supplier');
    }
    deleteSupp(val:any){
      return this.http.delete<any>(this.APIUrl+'/supplier/'+val);
    }
    // --------------------------ORDER-------------------------
    getOrderList():Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/order');
    }
    // ------------------------CATEGORY-------------------------
    getCategoryList():Observable<any[]>{
      return this.http.get<any>(this.APIUrl+'/category');
    }
  
}
