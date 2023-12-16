export const GetEventIdDescription = (eventId, navegador) => {
    navegador(`/detalhes-evento/${eventId}`);
}