import { Button, Card, CardContent, CardMedia, Paper, Stack, Typography } from '@mui/material';
import React from 'react'
import { colorTypeGradients } from '../utils/utils';

interface GoblinSaleParam {
    saleId: number;
    goblinId: number;
    image: string;
    name: string;
    type: number;
    goblinValue: number;
    onElemClick: (saleId: number) => void
}

export function GoblinSale(param: GoblinSaleParam) {

    /*let finalColor;

    if (type.length === 2) {
        finalColor = colorTypeGradients(type[0].type.name, type[1].type.name, type.length);
    } else {
        finalColor = colorTypeGradients(type[0].type.name, type[0].type.name, type.length);
    }*/

    return (
        <Card sx={{ maxWidth: 400, paddingX: 2 }}>
            <CardContent>
                <Stack direction={"row"} display={"flex"} justifyContent={"space-between"}>
                    <Typography variant={"subtitle1"} >{param.name}</Typography>
                    <Typography variant={"subtitle1"} >#{param.goblinId}</Typography>
                </Stack>
            </CardContent>
            <CardMedia
                component="img"
                height="300"
                image="https://2e.aonprd.com/Images/Monsters/Goblin_GoblinWarrior.png"
                alt="goblin"
            />
            <CardContent>
                <Typography variant={"h3"} >ETH {param.goblinValue}</Typography>
                <Typography variant={"subtitle2"} >race: {param.type}</Typography>
            </CardContent>
        </Card>
        /*<div className="thumbnail__container noselect" style={{ background: `linear-gradient(${finalColor[0]}, ${finalColor[1]})` }}>
            <div className="card__header">
                <div className="poke__number">
                    #{String(id).padStart(3, '0')}
                </div>
                <div className="info__icon" onClick={() => onElemClick({ name })}>
                    <svg stroke="currentColor" fill="currentColor" strokeWidth="0" viewBox="0 0 512 512" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M256 8C119.043 8 8 119.083 8 256c0 136.997 111.043 248 248 248s248-111.003 248-248C504 119.083 392.957 8 256 8zm0 110c23.196 0 42 18.804 42 42s-18.804 42-42 42-42-18.804-42-42 18.804-42 42-42zm56 254c0 6.627-5.373 12-12 12h-88c-6.627 0-12-5.373-12-12v-24c0-6.627 5.373-12 12-12h12v-64h-12c-6.627 0-12-5.373-12-12v-24c0-6.627 5.373-12 12-12h64c6.627 0 12 5.373 12 12v100h12c6.627 0 12 5.373 12 12v24z"></path></svg>
                </div>
            </div>
            <div className="image__container">
                <LazyLoadImage
                    alt="image-pokemon"
                    height={150}
                    src={param.image}
                    visibleByDefault={false}
                    delayMethod={'debounce'}
                    effect="blur"
                    className="img__thumbnail"
                />
            </div>
            <div className="poke__name" >
                <h3>{param.name}</h3>
                <div className="poke__type">
                    {type.map((type) =>
                        <Tooltip TransitionComponent={Zoom} key={type.type.name} title={type.type.name} arrow>
                            <div
                                className={`poke__type__bg ${type.type.name}`}>
                                <img draggable="false"  src={`${type.type.name}.png`} alt="poke-type"></img>
                            </div>
                        </Tooltip>
                    )}
                </div>
            </div>
        </div>*/
    )
}
