import { updateLocale } from "moment";
import { NewTaskModalBox } from "../Box/Box";
import { ContainerModal } from "../Container/style";
import { Title } from "../Text/Text";

export const NewTaskModal = ({ showModal, setShowModal, addTask, editModal, updateTask }) => {
  return showModal ? (
    <ContainerModal>
      <NewTaskModalBox editModal={editModal} addTask={addTask} updateTask={updateTask} closeModal={() => setShowModal(false)} />
    </ContainerModal>
  ) : null;
};
