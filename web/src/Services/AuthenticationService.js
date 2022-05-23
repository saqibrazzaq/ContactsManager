import Api from "../Api/Api";

const url = "Authentication";

export function login(data) {
  return Api.post(url + "/login", data);
}