# EscapeMaze
 
# 概要
かわいい敵キャラクターから逃げて、出口を目指して脱出しましょう！！
[![Image from Gyazo](https://i.gyazo.com/f911dbbcf89bc1196cf9e0034ce5c670.jpg)](https://gyazo.com/f911dbbcf89bc1196cf9e0034ce5c670)
[![Image from Gyazo](https://i.gyazo.com/36906322d7e5f94eb3bab2db3a3f633f.png)](https://gyazo.com/36906322d7e5f94eb3bab2db3a3f633f)
- ゲーム内容の動画
[![Image from Gyazo](https://i.gyazo.com/2475c74097262b90afedbe230abe6c3d.gif)](https://gyazo.com/2475c74097262b90afedbe230abe6c3d)
# 制作背景
ゲームを作りたいという思いから制作をスタートしました。
よく見る敵から逃げて脱出するゲームを参考にし制作しました。
私が作った最初の作品になります。

# 実装機能
## キャラクター操作
- キーボード操作(WASD)で動くように実装
- カメラの向いている方を基準に操作できるように実装
## カメラ操作
- マウス操作で、キャラクターを中心に見渡すことが可能
- 壁に近い場合、視点がキャラクターに寄るように実装
## 敵キャラクターの実装
- 4種類の敵キャラを配置
- 徘徊するのみの敵
- 永遠に追跡する敵
- 視野に入った場合にのみ動き追跡し、それ以外は動かない敵
- 視野に入った場合は追跡し、それ以外は徘徊する敵
## 画面遷移の実装
- タイトル画面からゲーム画面への遷移
- ゲーム画面からクリア画面、ゲームオーバー画面への遷移
- クリア画面、ゲームオーバー画面からタイトル画面への遷移
## クリア画面とゲームオーバ画面のテキストの動作
- DOTweenを用いて、テキストに動きを追加

# 使用技術
- ゲームエンジン : Unity
- 言語　：　C#
- 使用アセット : Unity-Chan! Model, 1 Monster Pack, (HOTween v2), Standard Assets (for Unity 2018.4), Wispy Skybox, Made Ground Materials, 10 Texture Sets 'Industrial 02'
