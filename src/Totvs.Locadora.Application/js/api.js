

class EasyHTTP {

    async get(url) {
        const response = await fetch(url);
        const resData = response.json();
        return resData;
    }

    async getById(url, id) {
        const response = await fetch(url + id);
        const resData = response.json();
        return resData;
    }

    async post(url, data) {

        const response = await fetch(url, {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
            redirect: 'follow'
        });
        const resData = await response;
        return resData;
    }
    async put(url, data) {

        const response = await fetch(url, {
            method: 'PUT',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
            redirect: 'follow'
        });
        const resData = await response;
        return resData;
    }

    async delete(url, id) {
        const response = await fetch(url + id, {
            method: 'DELETE',
            headers: { 'Content-type': 'application/json' }
        })
        const resData = await response;
        return resData;
    }
}

