import http from 'k6/http';
import { check, sleep } from 'k6';

// Configuration options for the load test.
export const options = {
    duration: '30s',
    //vus: 150,
    vus: 5,
    thresholds: {
        http_req_duration: ['p(95)<200','p(99)<300'],
        'checks':['rate>0.95']
    },
}

// Script for load test:
export default function() {
    const data = {
        "forumId": "9e2fa2fd-faf1-46ee-bc8e-030846d031d6",
        "topicName": "Anyone like loadtests?",
        "content": "I sure do love them!",
        "author": "LoadTest",

    }
    // Local:
    const res = http.post('http://localhost:80/threads-service/api/Threads', data)
    // Azure:
    //const res = http.get('http://20.238.149.147/threads-service/api/Threads');
    sleep(Math.random() * 5);
}