import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'yesNo'
})
export class FilterPipe implements PipeTransform {

  transform(textFields: boolean): any {
    if (textFields) {
      return "Yes"
    } else
      return "No";
  }



}
