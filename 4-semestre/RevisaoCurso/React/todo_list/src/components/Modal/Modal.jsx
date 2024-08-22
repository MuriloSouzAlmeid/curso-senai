import { NewTaskModalBox } from "../Box/Box";
import { ContainerModal } from "../Container/style";
import { Title } from "../Text/Text";

export const NewTaskModal = ({ toDoListArray, showModal, setShowModal }) => {
  return showModal ? (
    <ContainerModal>
      <NewTaskModalBox data={toDoListArray} closeModal={() => setShowModal(false)} />
    </ContainerModal>
  ) : null;
};
