import { environment } from "src/environments/environment";

export class Constants {
  private static BASE_URL = environment.apiUrl;

  static PRODUCT : string = `${this.BASE_URL}/Product`;
  static USER : string = `${this.BASE_URL}/User`;
}

