import axios from "axios";

export default axios.create({
    baseURL: window.apiUrl,
    headers: {
        "Content-type": "application/json"
    }
});