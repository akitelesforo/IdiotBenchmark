import http from "k6/http";
import { check, sleep } from "k6";

const API_URL = "https://httpbin.org/";

export let options = {
    vus: 1,
    duration: '1m'
};

export default function () {
    
    const res = http.get(API_URL);
    check(res, { "status was 200": (r) => r.status == 200 });
    sleep(1);
    
}