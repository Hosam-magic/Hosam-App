# Hosim-app

controller
|
|-GameController(遊戲相關事務，包含執行、更新、取得遊戲清單)
|-MotionSettingController(座椅設定相關操作)

Service
|
|-DataBaseService(用於檢查資料庫的完整性)
|-GameService(遊戲相關事務，包含執行、更新、取得遊戲清單)
|     |-GameDriverService(當遊戲起動或停止時，與副程式溝通)
|-MotionSettingService(座椅設定相關操作)  
