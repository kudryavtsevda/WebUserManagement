import axios from "axios";

export default axios.create({
    baseURL: "https://localhost:44397/api/users/",
    headers: {
        "Content-type": "application/json"
    }
});