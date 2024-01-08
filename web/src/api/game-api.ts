import axiosClient from "../helpers/axios.ts";
import { Grid } from "../models/game-models.ts"

export const gameInit = async (grid: Grid) => {
    return await axiosClient({
        method: "post",
        url: "/game",
        data: {
            gridX: grid.x,
            gridY: grid.y
        }
    }).then((res) => res.data)
}

export const fetchGameAPI = async () => {
    return await axiosClient({
        method: "get",
        url: "/game"
    }).then((res) => res.data)
}

export const sendCellData = async () => {
    return await axiosClient({
        method: "post",
        url:'/gamedata'
    })
}

export const startGameAPI = async (grid: Grid) => {
    return await axiosClient({
        method: "post",
        url: 'game/start',
        data: {
            gridX: grid.x,
            gridY: grid.y
        }
    }).then((res) => res.data)
}