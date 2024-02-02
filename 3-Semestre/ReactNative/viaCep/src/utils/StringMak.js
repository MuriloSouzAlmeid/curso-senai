import { mask, unMask } from "remask";

export const mascarar = (cepText) => mask(cepText, "99999-999") 

export const desmascarar = (cepTextMasked) => unMask(cepTextMasked) 