import http from "k6/http";
import { check, sleep } from "k6";

const API_URL = "https://httpbin.org/";

export let options = {
    stages: [
        { duration: '5m', target: 100 }, // simulate ramp-up of traffic from 1 to 100 users over 5 minutes.
        { duration: '10m', target: 100 }, // stay at 100 users for 10 minutes.
        { duration: '5m', target: 0 }, // ramp-down to 0 users.
    ]
};

export default function () {

    const res = http.get(API_URL);
    check(res, { "status was 200": (r) => r.status == 200 });
    sleep(1);

}