Python_3 = CreateDialog(function()

    Talk("JavaScript", "이제 더는 길이 없나봐?", "JS_Normal")
    Talk("Python", "...", "Python_Normal")
    Talk("Python", "판단 완료. 원하는 행동을 말씀해주세요.", "Python_Normal")

    local select = MakeSelect("Python", "판단 완료. 원하는 행동을 말씀해주세요.", "Phython_Normal",
    {
        "같이 가자",
        "글쎄, 소풍?"
    })
    Talk("Python", "......", "Python_Normal")
    Talk("Python", "...컴파일 완료. 문제 없음. 허나 조건 존재.", "Python_Normal")
    Talk("Python", "동행 시 1m 이상 거리 두기를 요청드립니다..", "Python_Normal")


end)