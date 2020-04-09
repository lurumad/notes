import axios from 'axios'
const baseUrl = '/api/notes'

const getAll = () => {
    const request = axios.get(baseUrl)
    return request.then(response => response.data)
}

const create = note => {
    const request = axios.post(baseUrl, note);
    return request.then(response => response.data)
}

const update = (id, note) => {
    const request = axios.put(`${baseUrl}/${id}`, note)
    return request.then(response => response.data)
}

export default { getAll, create, update }