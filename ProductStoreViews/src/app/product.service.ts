import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  readonly APIUrl = "https://localhost:44334/api/products";
  readonly PhotoUrl = "https://localhost:44334/Photos/";

  constructor(private http: HttpClient) { }

  getAllProducts() {
    return this.http.get(this.APIUrl);
  }

  getProduct(id: number) {
    return this.http.get(this.APIUrl + id);
  }

  addProduct(product: any) {
    console.log(product)
    const httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) }
    return this.http.post(this.APIUrl, JSON.stringify(product), httpOptions);
  }

  updateProduct(product: any) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
    return this.http.put(this.APIUrl, JSON.stringify(product), httpOptions);
  }

  deleteProduct(id: number) {
    return this.http.delete(this.APIUrl + '/' + id);
  }

}
