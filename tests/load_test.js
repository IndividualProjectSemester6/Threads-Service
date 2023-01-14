import http from 'k6/http';
import { check, sleep } from 'k6';

// Configuration options for the load test.
export const options = {
    duration: '1m',
    //vus: 150,
    vus: 5,
    thresholds: {
        http_req_failed: ['rate<0.1'],
        http_req_duration: ['p(95)<200','p(99)<300'],
        'checks':['rate>0.95']
    },
}

// Script for load test:
export default function() {
    // Local:
    //const res = http.get('http://192.168.2.6:80/threads-service/api/Threads')
    // Azure:
    const res = http.get('http://20.238.149.147/threads-service/api/Threads');
    check(res, {
        'is status 200': (r) => r.status === 200
    })
    sleep(Math.random() * 5);
}