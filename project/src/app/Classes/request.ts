
export class Request {
    constructor(
        public Patient_tz:number,
        public Date:Date,
        public Intek_date:Date,
        public Request__reaon:string,
        public Summary:string,
        public StatusId:number,
        public Talking1:string,
        public Talking1_date:Date,
        public Talking2:string,
        public Talking2_date:Date,
        public Notes:string,
        public StatusName:string,
    ){}
}

