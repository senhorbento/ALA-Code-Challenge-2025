export class User {
  id: number = -1;
  email: string = "";
  name: string = "";
}

export class UserLogin {
  user: string = "";
  password: string = "";
}

export class UserLoginResponse {
  role: string = "";
  token: string = "";
  name: string = "";
}

export class UserInsert {
  email: string = "";
  name: string = "";
}

export class UserUpdate {
  id: number = -1;
  email: string = "";
  name: string = "";
}
