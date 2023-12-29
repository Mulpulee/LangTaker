CSS_1 = CreateDialog(function()

    Talk("C#", "거기, 멈춰보세요!", "C#_Normal")
    Talk("C#", "외부인 추정, 당장 나가주시길 간청드립니다!", "C#_Normal")
    local select = MakeSelect("C#", "외부인 추정, 당장 나가주시길 간청드립니다!", "C#_Normal",
    {
        "아니, 못 가.",
        "안 가면 어떻게 되는데?"
    })
    if select == 0 then
        Talk("C#", "...이해가 안되네.", "C#_Normal")
        Talk("C#", "그럼 억지로라도 내보내는 수밖에!", "C#_Normal")

    elseif select == 1 then
        Talk("C#", "굳이 행동으로 해야 알아들으시겠습니까?", "C#_Normal")
        Talk("C#", "체벌입니다. 이후에도 반성할 기미가 안 보이면 시도하겠습니다.", "C#_Normal")
        Talk("C#", "더는 따라오지 마세요.", "C#_Normal")

    end

end)