import { Box, Dialog, DialogTitle, Typography } from "@mui/material";
import { GoblinStyles, MainStyles } from "../utils/style";

interface ResultDialogParam {
  onClose: () => void;
  open: boolean;
  children: any;
  title: string;
}

export function ResultDialog(props: ResultDialogParam) {

  const handleClose = () => {
    props.onClose();
  };

  return (
    <Dialog onClose={handleClose} open={props.open} >
      <DialogTitle sx={{ bgcolor: "#2b211f" }} >
        <Typography sx={{ ...GoblinStyles.sessionTitleText}}>{props.title}</Typography>
      </DialogTitle>
      <Box sx={{  ...MainStyles.floatingBox, ...MainStyles.container, pt: 0 }}>
        {props.children}
      </Box>
    </Dialog>
  );
}