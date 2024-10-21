import { Box, Divider, Paper, Stack, Typography, SxProps, Theme, Button } from "@mui/material";
import { UserQuestInfo } from "../dto/domain/UserQuestInfo";
import { GoblinStyles, MainStyles } from "../utils/style";
import DailyIcon from "../assets/images/quest/daily.png";
import GoblinIcon from "../assets/images/quest/goblin.png";
import QuestIcon from "../assets/images/quest/quest.png";
import WeeklyIcon from "../assets/images/quest/weekly.png";
import WorkIcon from "../assets/images/quest/work.png";
import { QuestPeriod } from "../dto/enum/QuestPeriod";
import { QuestType } from "../dto/enum/QuestType";
import Moment from "moment";
import { QuestStatus } from "../dto/enum/QuestStatus";
import { GetDuration } from "../utils/utils";
import { useTimer } from "react-timer-hook";
import { GetCardBackground, GetDifficultyColor, GetDifficultyName, GetQuestCategory, GetRewardBlock, GetStatusColor, GetStatusName } from "../utils/QuestUtils";
import { GenericSlot } from "./GenericSlot";
import { QuestCategoryEnum } from "../dto/enum/QuestCategoryEnum";
import { useState } from "react";
import { AnchorElItem } from "../dto/business/AnchorElItem";
import { ItemInfo } from "../dto/domain/ItemInfo";
import { ItemPopover } from "./ItemPopover";
import { useHistory } from "react-router";

interface QuestCardParam {
  userQuestInfo: UserQuestInfo;
  detail: (userQuestInfo: UserQuestInfo) => void;
}

interface TimerParam {
  expiryTimestamp: Date;
  title: string;
}

const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 16,
  bottom: 1,
  right: 4,
  position: "absolute"
}

const iconSize = 52;

export function QuestCard(param: QuestCardParam) {

  const history = useHistory();

  const [anchorEl, setAnchorEl] = useState<AnchorElItem>(null);

  const handleClick = (event: any, selectItem: ItemInfo) => {
      setAnchorEl({anchorEl: event, selectItem: selectItem});
  };

  const handleClosePopOver = () => {
      setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'questrewarddetail-popover' : undefined;

  function MyTimer(props: TimerParam) {
      const {
        seconds,
        minutes,
        hours,
        days,
        isRunning,
        start,
        pause,
        resume,
        restart,
      } = useTimer({ expiryTimestamp: props.expiryTimestamp, onExpire:  () => console.warn('onExpire called') });

      return (
        <Stack sx={{ ...MainStyles.container }}>
          <Typography sx={{ ...GoblinStyles.sessionTitleText }} >{props.title}</Typography>
          <Typography sx={{ ...GoblinStyles.textMain }} >{days + " days " + hours + " hr " + minutes + " min " + seconds + " sec"}</Typography>
        </Stack>
      );
  }


  const getCraftProgress = () => {
    let endDate = Moment(param.userQuestInfo.enddate).format("YYYYMMDDHHmmss");
    let now = Moment().utc().format("YYYYMMDDHHmmss");
    return endDate <= now;
  }

  const IsCompletedQuest = () => {
    return param.userQuestInfo.status != QuestStatus.Waiting && param.userQuestInfo.quest.questtype == QuestType.Quest;
  }

  const getJobRewardImg = () => {
    return (
      <>
        {
          GetQuestCategory(param.userQuestInfo.quest) == QuestCategoryEnum.BoxCraft ?
          <img draggable="false"  src={param.userQuestInfo.quest.reward.items[0].item.iconAsset} style={{ width: 100 }} alt={param.userQuestInfo.quest.reward.items[0].item.name} />
          : 
          <GenericSlot boxSize={90} key={param.userQuestInfo.quest.reward.items[0].item.key} rarity={param.userQuestInfo.quest.reward.items[0].item.rarity} >
            {
              <Box sx={{ ...MainStyles.container, height: 85, width: 85, position: "relative" }} > 
                <img draggable="false"  src={param.userQuestInfo.quest.reward.items[0].item.iconAsset} style={{ width: "100%" }} alt={param.userQuestInfo.quest.reward.items[0].item.name} />
                <Typography sx={{...styleQtde}}>{param.userQuestInfo.quest.reward.items[0].qtde}</Typography>
              </Box>
            }
          </GenericSlot>
        }
      </>
    )
  }

  return (
    <Paper sx={{ ...MainStyles.container, borderRadius: 3, width: 314, bgcolor: GetDifficultyColor(param.userQuestInfo.quest.difficulty), pb: "2px", pt: "2px" }} elevation={8}>
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 0, pb: 2, borderRadius: 3, width: 310 }} elevation={6} >
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1}>
          <Box sx={{ ...MainStyles.container, position: "relative", width: 310, height: 180 }}>
            <Box sx={{ position: "absolute", top: 0, width: 310, height: 180 }} >
              <img draggable="false"  src={GetCardBackground(param.userQuestInfo.quest)} style={{ width: "100%", height: "100%", borderTopLeftRadius: 12, borderTopRightRadius: 12, position: "absolute", top: 0 }} />
              <Box sx={{ width: 1, height: 1, position: "absolute", top: 0, background: "linear-gradient(0deg, rgba(0,0,0,0.6) 0%, rgba(239,239,239,0.01) 50%, rgba(0,0,0,0.6) 100%);", 
                borderTopLeftRadius: 12, borderTopRightRadius: 12 }} />
            </Box>
            <Stack sx={{ ...MainStyles.container, width: 1, position: "absolute", top: 12, opacity: IsCompletedQuest() ? 0.4 : 1 }} spacing={3}>
              <Typography sx={{ ...GoblinStyles.textMain }}>{param.userQuestInfo.quest.name}</Typography>  
              <Stack direction={"row"} sx={{ ...MainStyles.container, justifyContent: "space-evenly", width: 1 }}>
                <Stack sx={{ ...MainStyles.container }}>
                  {
                    param.userQuestInfo.quest.questtype == QuestType.Quest &&
                    <>
                      <img draggable="false"  src={param.userQuestInfo.quest.period == QuestPeriod.Daily ? DailyIcon : WeeklyIcon} alt={"goblin"} style={{ height: iconSize }} />
                      <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.userQuestInfo.quest.period == QuestPeriod.Daily ? "Daily" : "Weekly"}</Typography>
                    </>
                  }
                  {
                    param.userQuestInfo.quest.questtype == QuestType.Job &&
                    getJobRewardImg()
                  }
                </Stack>
                <Stack sx={{ ...MainStyles.container }}>
                  <img draggable="false"  src={param.userQuestInfo.quest.questtype == QuestType.Quest ? QuestIcon : WorkIcon} alt={"goblin"} style={{ height: iconSize }} />
                  <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.userQuestInfo.quest.questtype == QuestType.Quest ? "Mission" : "Job"}</Typography>
                </Stack>
                {
                  param.userQuestInfo.quest.questtype == QuestType.Quest &&
                  <Stack sx={{ ...MainStyles.container }} >
                    <img draggable="false"  src={GoblinIcon} alt={"goblin"} style={{ height: iconSize }} />
                    <Typography sx={{ ...GoblinStyles.sessionTitleText }}>x{param.userQuestInfo.quest.qtdemax}</Typography>
                  </Stack>
                }
              </Stack>
            </Stack>
            {
              IsCompletedQuest() &&
              <Box sx={{ ...MainStyles.container, position: "absolute", top: 1, height: 1, width: 1 }}>
                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                  <Typography sx={{ ...GoblinStyles.textMain, color: GetStatusColor(param.userQuestInfo.status), fontSize: 50 }}>{GetStatusName(param.userQuestInfo.status)}</Typography>
                </Stack>
              </Box>
            }
          </Box>
          {
            param.userQuestInfo.quest.questtype == QuestType.Quest &&
            <Typography sx={{ ...GoblinStyles.textMain, color: GetDifficultyColor(param.userQuestInfo.quest.difficulty) }}>{GetDifficultyName(param.userQuestInfo.quest.difficulty)}</Typography>
          }
          {
            param.userQuestInfo.quest.questtype == QuestType.Quest &&
            GetRewardBlock(param.userQuestInfo.quest, (ev: any, item: ItemInfo) => {
              handleClick(ev.currentTarget, item);
            })
          }
          {
            IsCompletedQuest() &&
            <Stack sx={{ ...MainStyles.container }} spacing={2} >
              {
                param.userQuestInfo.status != QuestStatus.Started && 
                <Stack sx={{ ...MainStyles.container }} >
                  <MyTimer title={"Repeatable in"} expiryTimestamp={new Date(Moment(param.userQuestInfo.expiredate).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())}  />
                </Stack>
              }
            </Stack>
          }
          {
            param.userQuestInfo.status == QuestStatus.Started && param.userQuestInfo.quest.questtype == QuestType.Job &&
            <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2} >
              <Stack sx={{ ...MainStyles.container, width: 1, px: 2 }} spacing={0} >
                {
                  getCraftProgress() ? 
                  <Typography sx={{ ...GoblinStyles.textMain, color: GetStatusColor(QuestStatus.Success) }}>Finished</Typography>
                  : <MyTimer title={"Craft ends in"} expiryTimestamp={new Date(Moment(param.userQuestInfo.enddate).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())}  />
                }
                
              </Stack>
            </Stack>
          }
          {
            param.userQuestInfo.status == QuestStatus.Waiting && 
            <Stack sx={{ ...MainStyles.container }}>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>Time cost</Typography>
              <Typography sx={{ ...GoblinStyles.textMain }}>{GetDuration(param.userQuestInfo.quest.timemin*1000, true)} ~ {GetDuration(param.userQuestInfo.quest.timemax*1000, true)}</Typography>
            </Stack>
          }
          <Button sx={{ ...MainStyles.mainButton, width: 200 }} onClick={() => { param.detail(param.userQuestInfo) }} >Details</Button>
        </Stack>
      </Paper>
      <ItemPopover anchorEl={anchorEl} equipCb={() => {}} moreDetail={(item: ItemInfo) => {
        history.push("/equipment?key=" + item.key);
      }} loading={false} open={open} closeCb={handleClosePopOver} id={id} canEquip={false} />
    </Paper>
  )
}