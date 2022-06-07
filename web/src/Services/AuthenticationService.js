import Api from "../Api/Api";

const url = "Users";

export function login(data) {
  console.log('data posted to api')
  console.log(data);
  return Api.post(url + "/authenticate", data);
}

export function logout() {
  return Api.post(url + "/logout");
}