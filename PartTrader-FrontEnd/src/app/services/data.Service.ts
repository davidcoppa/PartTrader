import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DataService {

    subjectName = new Subject<any>(); //need to create a subject

    sendUpdateObject(data: any) { //the component that wants to update something, calls this fn
        this.subjectName.next( data); //next() will feed the value in Subject
    }
    sendUpdate() {
        this.subjectName.next({});
    }
    getUpdate(): Observable<any> { //the receiver component calls this function 
        return this.subjectName.asObservable(); //it returns as an observable to which the receiver funtion will subscribe
    }

    
}