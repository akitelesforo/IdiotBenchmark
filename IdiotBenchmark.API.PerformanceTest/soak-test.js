import http from "k6/http";
import { check, sleep } from "k6";

const API_URL = "https://httpbin.org/";

export let options = {
    stages: [
        { duration: '2m', target: 400 }, // ramp up to 400 users
        { duration: '3h56m', target: 400 }, // stay at 400 for ~4 hours
        { duration: '2m', target: 0 }, // scale down. (optional)
    ]
};

export default function () {

    const res = http.get(API_URL);
    check(res, { "status was 200": (r) => r.status == 200 });
    sleep(1);

}