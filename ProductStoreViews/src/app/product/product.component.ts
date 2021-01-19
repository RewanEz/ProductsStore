import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ExportToExcelService } from '../export-to-excel.service';
import { Product } from '../product';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private service: ProductService, private exportService: ExportToExcelService) { }

  Products: any = [];
  newProduct: Product = new Product();
  searchText: string = '';

  ngOnInit(): void {
    this.loadAllProducts();
  }

  loadAllProducts() {
    this.service.getAllProducts().subscribe(data => {
      console.log(data);
      this.Products = data;
    })
  }

  onSubmit(formObj: Product) {
    if (!formObj.ID)
      this.service.addProduct(formObj).subscribe(() => { this.loadAllProducts() });
    else
      this.service.updateProduct(formObj).subscribe(() => { this.loadAllProducts() });

    this.loadAllProducts();
  }

  editClick(item: any) {
    console.log(item);
    this.newProduct.ID = item.id;
    this.newProduct.Name = item.name;
    this.newProduct.Price = item.price;
    this.newProduct.PhotoUrl = item.photoUrl;
  }

  deleteClick(item: any) {
    console.log(item)
    if (confirm('Are you sure??')) {
      this.service.deleteProduct(item).subscribe(() => {
        this.loadAllProducts();
      })
    }
  }

  exportClick(item: any) {
    this.exportService.exportExcel([item], item.name)
  }

}
