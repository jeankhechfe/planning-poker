import {AppComponent} from '../app.component';
import {User} from '../_model/user';
import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {UserLoginTO} from './userlogin';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getDetails() {
    return this.http.get<User[]>(`${AppComponent.apiUrl}/user`);
  }

  register(user: User) {
    return this.http.post(`${AppComponent.apiUrl}/register`, user);
  }

  login(user: UserLoginTO) {
    return this.http.post(`${AppComponent.apiUrl}/login`, user);
    // TODO pipe to auth service
  }
}
