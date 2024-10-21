import StatusRequest from "./StatusRequest";

export default interface TweetUrlResult extends StatusRequest {
  tweeturl: string;
}