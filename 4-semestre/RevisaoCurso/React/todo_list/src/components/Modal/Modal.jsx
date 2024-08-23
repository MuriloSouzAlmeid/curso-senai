import { updateLocale } from "moment";
import { NewTaskModalBox } from "../Box/Box";
import { ContainerModal } from "../Container/style";
import { Title } from "../Text/Text";

export const NewTaskModal = ({ showModal, addTask, editModal, updateTask, index, descriptionEdit, closeModal }) => {
  return showModal ? (
    <ContainerModal>
      <NewTaskModalBox closeModal={closeModal} descriptionEdit={descriptionEdit} index={index} editModal={editModal} addTask={addTask} updateTask={updateTask} />
    </ContainerModal>
  ) : null;
};
