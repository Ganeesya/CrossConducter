//////////////////////////////////////////////////////////
/
/      CrossConducter                    (制作 がねーしゃ twitter@Ganeesya)
/
//////////////////////////////////////////////////////////

このソフトは複数の生放送サイトのコメントを取得し、読み上げソフトに投げるソフトです
対応するボイスロイドや棒読みちゃんが必要です
別個用意してください

//////////////////////////////////////////////////////////
　　使用規約

利用に関する責任は全て利用者にあります。
全て自己責任の元、ご自由にお使いください。

//////////////////////////////////////////////////////////
　　プラグインについて
このプログラムはほとんどの機能をプラグインにしています
ソースコード全体は以下のGithubで公開しているので
そちらを参考に標準以外の機能を追加することもできます

https://github.com/Ganeesya/CrossConducterProject

//////////////////////////////////////////////////////////
　　標準で用意される機能

　☆入力
AnkoReader 		あんこちゃん入力

YoutubeReader 	Youtubeコメント取得

RestreamReader	RestreamChat経由取得

　☆処理
Task_Yomikae 	出力先自動切り替え
Task_Yomiyame 	出力取りやめ
Task_Lua		Lua制御

　☆出力
Out_Bouyomi 	棒読みちゃん

Out_Akane		ボイスロイド
Out_Aoi
Out_Maki
Out_Yukari
Out_Zunko

//////////////////////////////////////////////////////////

2017/09/11		0.01ｂ	いろいろと変更
2016/09/09		0.00ｂ	β公開

//////////////////////////////////////////////////////////
使用ライブラリライセンス表記

Google.Apis
http://www.apache.org/licenses/LICENSE-2.0

bouncycastle
http://www.bouncycastle.org/csharp/licence.html

Newtonsoft.Json
https://raw.githubusercontent.com/JamesNK/Newtonsoft.Json/master/LICENSE.md

log4net
http://logging.apache.org/log4net/license.html