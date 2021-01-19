import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../product';

@Pipe({
    name: 'search'
})
export class SearchPipe implements PipeTransform {
    transform(items: any[], filter: string): any {
        if (!items || !filter) {
            return items;
        }
        let b = items.filter(item => new RegExp(filter, "gi").test(item.name));
        return b;
    }

}