 export class User {
  id: number = -1;
  email: string = "";
  password?: string;
  name: string = "";
  role: string = "user";
}

export class UserLoginResponse {
  role: string = "";
  name: string = "";
  token: string = "";
}

export class UserLogin {
  email: string = "";
  password: string = "";
}

export class UserInsert {
  email: string = "";
  name: string = "";
  password?: string = "";
  role: string = "user";
}

export class UserUpdate {
  id: number = -1;
  email: string = "";
  password?: string = "";
  name: string = "";
  role: string = "user";
}