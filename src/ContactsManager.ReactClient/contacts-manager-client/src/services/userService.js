const baseUrl = 'https://localhost:44334/identity';

export const register = async (username, email, password) => {
    let response = await fetch(`${baseUrl}/register`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ username, email, password })
    });
    
    return response.ok;
}

export const login = async (username, password ) => {
    let response = await fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ username, password })
    });

    let result = await response.json();

    if (response.ok) {
        return result;
    } else {
        throw result.message;
    }
}