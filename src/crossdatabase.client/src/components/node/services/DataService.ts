const urls = {
    getNode: `api/node`
}


export default {
    getNode() {
        const result = fetch(urls.getNode, {
            method: `GET`
        }).then(response => response.json());

        return result;
    }
}
