export class UserLoginTO {
  // tslint:disable-next-line:variable-name
  private _login: string;

  get login(): string {
    return this._login;
  }

  set login(value: string) {
    this._login = value;
  }
}
