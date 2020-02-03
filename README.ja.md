# Telledge
This is a English documentation for the project, look [here](./README.md) if you need English one.

## 機能紹介
このシステムを通して”知識”を学習する機会を提供します。
または、講師として知識を学ぶ生徒の助けをすることもできます。
私たちと常識を超えましょう。

## なぜTelledge?
今現在、世界中には様々な学習システムが存在しています。  
例えば、Youtube、Twitter、ブログ、などなど。  
私たちはこれらから得られるものはただの”情報”だと考えています。  
しかし、Telledgeは情報を知識として提供します。  
情報と知識には大きな違いがあります。  
情報を知識としてシステムを通して学習してもらえると幸いです。  

## 要求事項
OS：Windows 10
開発環境 : Visual Studio 2017以降のバージョン

## インストール方法
以下のステップの順番に設定を進めてください。
1. リポジトリからクローンする。
2. 設定ファイルを準備する。  
	2-1. 新しく`Authentication.config`をリポジトリルートのtelledgeディレクトリに作成。  
		以下に設定ファイルの例を示します。必要な項目を変更して保存してください。
		   
		<?xml version="1.0"?>  
		<connectionStrings>  
    		<add name="Db" connectionString="Data Source=TypeYourDBHost;Initial Catalog= TypeYourCatalog;User ID = TypeYourId;Password=TypeYourPassword" />  
		</connectionStrings>  
	     
	2-2. 新しく`App.config`をリポジトリルートのUnitTestディレクトリに作成.
		以下に設定ファイルの例を示します。必要な項目を変更して保存してください。

	<?xml version="1.0" encoding="utf-8" ?>
	<configuration>
		<appSettings>

		</appSettings>

		<connectionStrings>
		  <add name="Db" connectionString="Data Source=TypeYourDBHost;Initial Catalog= TypeYourCatalog;User ID = TypeYourId;Password=TypeYourPassword" /> 
		</connectionStrings>
	</configuration>

## 使い方(講師)
講師としてログインします。  
講師は自分のルームを作成し、あなたのスキルを学びたいと思う生徒が来るまで待機します。  
通話中はしっかりとスキルを教えてください。  
通話終了時、停止ボタンを押してください。休憩が待っています。  
次の生徒が待っているので休憩が終わったら対応を続けてください。  

## 使い方(生徒)
生徒としてログインします。  
一覧からか検索をして、気になるルームを選択してください。  
ルームに参加したら講師があなたに電話をかけるまで待機してください。  
もし講師を気に入ったら高評価をつけてください ^^  

## ライセンス
[ライセンス(英語)](./LICENSE)
