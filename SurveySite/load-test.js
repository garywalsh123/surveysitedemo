import http from "k6/http";

export const options = {
  // define thresholds
  thresholds: {
    http_req_failed: ['rate<0.01'], // http errors should be less than 1%
    http_req_duration: ['p(99)<5000'], // 99% of requests should be below 5s
  },
  // define scenarios
  scenarios: {
    // arbitrary name of scenario
    average_load: {
      executor: "ramping-vus",
      stages: [
        // ramp up to average load of 20 virtual users
        { duration: "10s", target: 200},
        // maintain load
        { duration: "120s", target: 200 },
        // ramp down to zero
        { duration: "50s", target: 0 },
      ],
    },
  }
};

export default function () {
  const response = http.post("https://localhost:7214/api/Survey");
}