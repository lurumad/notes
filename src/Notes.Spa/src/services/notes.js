import axios from "axios";
import store from "../stores/store";

const baseUrl = `${process.env.REACT_APP_API}/api/notes`;

const getAll = () => {
  const user = store.getState().user;
  console.log(user);
  const request = axios.get(baseUrl, {
    headers: { Authorization: `Bearer ${user.access_token}` },
  });
  return request.then((response) => response.data);
};

const create = (note) => {
  const user = store.getState().user;
  const request = axios.post(baseUrl, note, {
    headers: { Authorization: `Bearer ${user.access_token}` },
  });
  return request.then((response) => response.data);
};

const update = (id, note) => {
  const user = store.getState().user;
  const request = axios.put(`${baseUrl}/${id}`, note, {
    headers: { Authorization: `Bearer ${user.access_token}` },
  });
  return request.then((response) => response.data);
};

const remove = (id) => {
  const user = store.getState().user;
  const request = axios.delete(`${baseUrl}/${id}`, {
    headers: { Authorization: `Bearer ${user.access_token}` },
  });
  return request.then((_) => _);
};

const removeAll = () => {
  const user = store.getState().user;
  const request = axios.delete(`${baseUrl}`, {
    headers: { Authorization: `Bearer ${user.access_token}` },
  });
  return request.then((_) => _);
};

export default {
  getAll,
  create,
  update,
  remove,
  removeAll,
};
