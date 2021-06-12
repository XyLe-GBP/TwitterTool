# TwitterTool

A simple Twitter client.

---

## Download

[Release](https://github.com/XyLe-GBP/TwitterTool/Release)

---

## Description

It is a simple user interface application that enables tweeting via tools via Twitter API.

Currently, only Japanese is supported as the application language.

If you would like me to support a different language, please contact me on [Website](https://xyle-official.com/contact) or [Twitter](https://twitter.com/X1LeP).

---

### Requirements

.NET 5 runtime installation and an Internet connection are required to use this tool.

[.NET 5 Runtime](https://dotnet.microsoft.com/download/dotnet/5.0)

In order to use all the features of the application, you need to apply for the developer account from the [Twitter Developer Portal](https://developer.twitter.com/en/apps/).

If you already have a developer account, you can use the TwitterAPI application token to use all the features of this application.

To use this application, you will need the following token information:

  `CONSUMER_KEY (25 alpha-numeric characters)`
  
  `CONSUMER_SECRET (50 alpha-numeric characters)`
  
  `ACCESS_TOKEN (50 alpha-numeric characters)`
  
  `ACCESS_SECRET (45 alpha-numeric characters)`
  
Also, Bearer Token is not necessarily required.
(You can add it if you want).
  
  `BEARER_TOKEN (116 alpha-numeric characters)`
  
The token can be set from the menu item `設定 > トークン設定`.

※If you do not have a token, you will not be able to use most of the features of the application.

In this case, you will need to apply for a [developer account](https://developer.twitter.com/en/apps/).

The TwitterAPI application used in this application requires the

`Developer Portal >> STANDALONE APPS >> Authentication settings >> Edit >> Enable 3-legged OAuth`s field must be enabled.

※If you do not set this, you will not be able to authenticate with this application and will not be able to add accounts.

The `Callback URLs (required)` and `Website URLs (required)` items can be any values you like.

To add an account, you can click to `設定 >> アカウント設定 >> アカウント追加`.

A maximum of five accounts can be added. If you want to add more accounts, please delete the old registered accounts.

---

### Features of this application

`Currentry version: 0.1.0000.612`

※This application is still under development. There may be unexpected bugs or errors.

If you find a bug, please contact me via [Issues](https://github.com/XyLe-GBP/TwitterTool/issues) or my [Twitter](https://twitter.com/X1LeP).

* Ability to tweet, tweet with image, and tweet with video with the account registered in the application
* Ability to retrieve and display up to 300 of your own timelines and home timelines.

※Due to the limitations of the Twitter API, you cannot retrieve more than 300 at a time.

* Ability to like, retweet, and reply to other users' tweets

※Excessive liking and retweeting via applications may result in your account being frozen.

* Ability to search for tweets that contain specific keywords
* Ability to display detailed information about a tweet
* Ability to view user profiles
* Ability to follow, block, and mute users
* Ability to prevent users' retweets from being displayed
* Ability to view which users are following you and which users are not following you (under development)
* Ability to bulk block users who tweet specific keywords (under development)
* Ability to tweet the song currently playing on your PC via #NowPlaying (under development)

---

### About Licensing

<p>This tool is released under the MIT license.</p>
