import http from 'k6/http';
import { check, sleep } from 'k6';

// Configuration options for the load test.
export const options = {
    duration: '30s',
    vus: 2000,
    thresholds: {
        http_req_duration: ['p(95)<9000','p(99)<10000'],
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
    //const res = http.post('http://localhost:80/threads-service/api/Threads', data)
    // Azure:
    const res = http.post('http://20.238.149.147/threads-service/api/Threads', data);
    sleep(1);
}