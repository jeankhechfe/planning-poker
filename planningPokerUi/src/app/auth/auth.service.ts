import {User} from '../_model/user';
import {UserLoginTO} from './userlogin';
import {LoginTokenTO} from './token';
import {Injectable} from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  token: string;
  user: User;

  constructor() {
    this.token = null;
    this.user = null;
  }

  getCurrentUser(): User {
    return this.user;
  }

  login(loginTokenTO: LoginTokenTO, user: User){
    this.user = user;
    this.token = loginTokenTO.token;
  }

  logout(){
    this.user = null;
    this.token = null;
    // TODO some token deactivation
  }
}
