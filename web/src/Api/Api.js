import axios from "axios";

const BASE_URL = "https://localhost:7232/api/v1";

axios.defaults.withCredentials = true

// For public API access
export default axios.create({
  baseURL: BASE_URL
});

// // For private API access, which uses JWT tokens and auth
// export const axiosPrivate = axios.create({
//   baseURL: BASE_URL,
//   headers: {
//     "content-type": "application/json",
//   },
//   withCredentials: true,
// });
