const baseUrl = 'https://localhost:44334/contacts';

export function getAll() {
    return fetch(baseUrl)
        .then(res => res.json());
}

export function getById (id) {
    return fetch(`${baseUrl}/details/${id}`)
        .then(res => res.json());
}
    

export function getByName(name) {
    return fetch(`${baseUrl}/${name}`)
        .then(res => res.json());
}

export function create () {
    return fetch(`${baseUrl}/create`)
        .then(res => res.json());
}

export function update () {
    return fetch(`${baseUrl}/update`)
        .then(res => res.json());
}

export function remove (id) {
    return fetch(`${baseUrl}/delete/${id}`)
        .then(res => res.json());
}