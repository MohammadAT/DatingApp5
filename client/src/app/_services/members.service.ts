import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  baseUrl = environment.apiUrl;
  Members: Member[] = [];

  constructor(private http: HttpClient) {}

  getMembers() {
    if ((this.Members.length > 0)) return of(this.Members);
    return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
      map((memers) => {
        this.Members = memers;
        return memers;
      })
    );
  }

  getMember(username: string) {
    const member = this.Members.find(x=> x.username == username);
    if (member !== undefined) {
      return of(member);
    }
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'users', member).pipe(
      map(() => {
        const index = this.Members.indexOf(member);
        this.Members[index] = member;
      })
    );
  }
}
