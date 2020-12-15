# unity_project

## 遊戲按鍵

F 撿武器  
Q 換武器  
G 傳送門

## 版控

* initial

```cmd
git checkout -b [yourbranch]
git fetch origin main
git merge origin/main
```

第二行是更新本地進度(引入 main 進度)
第三行是要接在第二行後面，才會更新。

* loop

```cmd
git add .
git commit
git push
```

`git push` 更新到 yourbranch 讓大家看到你的進度。  
確定好了就到專案網頁 pull request 並接受，並且 **確定 reqest 是 base:main  compare:yourbranch**  

## 資料夾

game/level1/ 是第一關 justin 你要在這裡放你的美工成品，  
要甚麼東西到 pau1234/ 找，注意不要添加或修改裡面的東西，要改自己複製出去在你的資料夾(自己創)改。  
scene/ 基本上只有美工能動(遊戲成品)，  
要測試在其他資料夾造 scene 自己測。  
[readme/](readme/) (Assets 外面) 會放其他說明文件。  

