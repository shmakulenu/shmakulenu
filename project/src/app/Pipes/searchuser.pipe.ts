import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchuser'
})
export class SearchuserPipe implements PipeTransform {

  transform(value: any, args?: any): any {

    if (!args)
      return value;
    // חיפוש עובד לפי ת.ז או שם או טלפון
    return value.filter(u => u.User_tz.toString().indexOf(args) != -1 ||
      u.User_name.indexOf(args) != -1 || u.Last_name.indexOf(args) != -1);
  }

}

