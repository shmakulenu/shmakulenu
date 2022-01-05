import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchpatient'
})
export class SearchpatientPipe implements PipeTransform {

  transform(value: any, args?: any): any {

    if (!args)
      return value;
    // חיפוש תלמיד לפי ת.ז או שם או טלפון
    return value.filter(p => p.First_name.indexOf(args) != -1 || p.Tz.toString().indexOf(args) != -1 ||
      p.Tellephone1.toString().indexOf(args) != -1 || p.Tellephone2.toString().indexOf(args) != -1);
  }

}
