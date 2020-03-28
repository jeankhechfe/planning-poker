export class User {
  // tslint:disable-next-line:variable-name
  private _id: string;
  // tslint:disable-next-line:variable-name
  private _login: string;

  constructor() {
  }

  get id(): string {
    return this._id;
  }

  set id(value: string) {
    this._id = value;
  }

  get login(): string {
    return this._login;
  }

  set login(value: string) {
    this._login = value;
  }
}
