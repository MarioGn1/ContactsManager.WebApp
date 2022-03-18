const baseUrl = 'https://localhost:44334/identity';

export function register() {
    return fetch(`${baseUrl}/register`)
        .then(res => res.json());
}

export function login() {
    return fetch(`${baseUrl}/login`)
        .then(res => res.json());
}